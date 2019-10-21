using AutoMapper;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoClients.Core
{
    public class MappingProfile : Profile
    {
        public string clave = "InfoClientsEncrypt";
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Client, Dtos.Client>()
                .ForMember(destination => destination.Nit,
                map => map.MapFrom(
                    source => descifrar(source.Nit)));
            CreateMap<Dtos.Client, Domain.Entities.Client>()
                .ForMember(destination => destination.Nit,
                map => map.MapFrom(
                    source => cifrar(source.Nit)));

            CreateMap<Domain.Entities.Country, Dtos.Country>();
            CreateMap<Domain.Entities.State, Dtos.State>();
            CreateMap<Domain.Entities.City, Dtos.City>();
        }

        public string cifrar(string cadena)
        {

            byte[] llave; 

            byte[] arreglo = UTF8Encoding.UTF8.GetBytes(cadena); 

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(clave));
            md5.Clear();


            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = llave;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateEncryptor(); 
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length); 
            tripledes.Clear();

            return Convert.ToBase64String(resultado, 0, resultado.Length); 
        }

        public string descifrar(string cadena)
        {

            byte[] llave;

            byte[] arreglo = Convert.FromBase64String(cadena); 


            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(clave));
            md5.Clear();


            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = llave;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateDecryptor();
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length);
            tripledes.Clear();

            string cadena_descifrada = UTF8Encoding.UTF8.GetString(resultado); 
            return cadena_descifrada; 
        }

    }
}
