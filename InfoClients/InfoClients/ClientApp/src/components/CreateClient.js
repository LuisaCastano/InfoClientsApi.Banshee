import React, { Component } from 'react';

export class CreateClient extends Component {
    static displayName = CreateClient.name;
    constructor(props) {
        super(props);
        this.state = {
            countries: [],
            states: [],
            cities: [],
            loading: true,
            selectedCountry: "",
            seletedCity: "",
            seletedState: "",
            validationError: ""
        };
        this.handleSubmit = this.handleSubmit.bind(this);
        fetch("api/Master/GetAllCountry")
            .then((response) => {
                return response.json();
            })
            .then(data => {
                let countryFromApi = data.map(country => { return { value: country.id, display: country.nameCountry } })
                this.setState({ countries: [{ value: '', display: '(Selecione el país)' }].concat(countryFromApi) });
            }).catch(error => {
                console.log(error);
            });

        fetch("api/Master/GetAllState")
            .then((response) => {
                return response.json();
            })
            .then(data => {
                let stateFromApi = data.map(state => { return { value: state.id, display: state.nameState } })
                this.setState({ states: [{ value: '', display: '(Selecione el departamento)' }].concat(stateFromApi) });
            }).catch(error => {
                console.log(error);
            });

        fetch("api/Master/GetAllCity")
            .then((response) => {
                return response.json();
            })
            .then(data => {
                let cityFromApi = data.map(city => { return { value: city.id, display: city.nameCity } })
                this.setState({ cities: [{ value: '', display: '(Selecione la ciudad)' }].concat(cityFromApi) });
            }).catch(error => {
                console.log(error);
            });
    }

    handleSubmit(event) {
        event.preventDefault();
        const data = new FormData(event.target);

        fetch('api/clients', {
            method: 'POST',
            body: data,
        });
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <div class="form-group">
                    <label htmlFor="nit">Nit: </label>
                    <input id="nit" name="nit" type="text" />
                </div>
                <div class="form-group">
                    <label htmlFor="fullName">Nombre completo: </label>
                    <input id="fullName" name="fullName" type="text" />
                </div>
                <div class="form-group">
                    <label htmlFor="address">Dirección: </label>
                    <input id="address" name="address" type="text" />
                </div>
                <div class="form-group">
                    <label htmlFor="phone">Telefono: </label>
                    <input id="phone" name="phone" type="text" />
                </div>
                <div class="form-group">
                    <label>País: </label>
                    <select name="countryId" value={this.state.selectedCountry}
                        onChange={(e) => this.setState({ selectedCountry: e.target.value, validationError: e.target.value === "" ? "Debes selecionar un país" : "" })}>
                        {this.state.countries.map((country) => <option key={country.value} value={country.value}>{country.display}</option>)}
                    </select>
                    <div style={{ color: 'red', marginTop: '5px' }}>
                        {this.state.validationError}
                    </div>
                </div>
                <div class="form-group">
                    <label>Departamento: </label>
                    <select name="stateId" value={this.state.selectedState}
                        onChange={(e) => this.setState({ selectedState: e.target.value, validationError: e.target.value === "" ? "Debes Selecionar un departamento" : "" })}>
                        {this.state.states.map((state) => <option key={state.value} value={state.value}>{state.display}</option>)}
                    </select>
                    <div style={{ color: 'red', marginTop: '5px' }}>
                        {this.state.validationError}
                    </div>
                </div>
                <div class="form-group">
                    <label>Ciudad: </label>
                    <select name="cityId" value={this.state.selectedCity}
                        onChange={(e) => this.setState({ selectedCity: e.target.value, validationError: e.target.value === "" ? "Debes selecionar una ciudad" : "" })}>
                        {this.state.cities.map((city) => <option key={city.value} value={city.value}>{city.display}</option>)}
                    </select>
                    <div style={{ color: 'red', marginTop: '5px' }}>
                        {this.state.validationError}
                    </div>
                </div>
                <div class="form-group">
                    <label htmlFor="creditLimit">Limite de credito: </label>
                    <input id="creditLimit" name="creditLimit" type="text" />
                </div>
                <button>Send data!</button>
            </form>
        )
    }
}
