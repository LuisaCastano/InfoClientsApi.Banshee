import React, { Component } from 'react';

export class ClientData extends Component {
    static displayName = ClientData.name;

    constructor(props) {
        super(props);
        this.state = { client: [], loading: true };

        fetch('api/Clients/GetAllClients')
            .then(response => response.json())
            .then(data => {
                this.setState({ client: data, loading: false });
            });
    }

    static renderClientsTable(client) {
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Nit</th>
                        <th>Nombre Completo</th>
                        <th>Credito</th>
                        <th>Consumo</th>
                    </tr>
                </thead>
                <tbody>
                    {client.map(client =>
                        <tr key={client.id}>
                            <td>{client.nit}</td>
                            <td>{client.fullName}</td>
                            <td>{client.creditLimit}</td>
                            <td>{client.availableCredit}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ClientData.renderClientsTable(this.state.client);

        return (
            <div>
                <h1>Clientes</h1>
                <p>Lista de clientes</p>
                {contents}
            </div>
        );
    }
}
