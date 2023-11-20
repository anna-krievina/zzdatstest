import React, { Component } from 'react';

export class Metals extends Component {
    constructor(props) {
        super(props);
        this.state = { metaldata: [] };
    }

    componentDidMount() {
        fetch("/Contaminants/MetalsInSpecies")
            .then(function (response) {
                return response.json();
            })
            .then(items => this.setState({ metaldata: items }));
    }

    renderTable() {
        return (
            <div>
                <table className='table table-striped table-bordered table-sm' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Paraugam noteiktie parametri</th>
                            <th>Zivju suga</th>
                            <th>Paraugā apvienots īpatņu skaits</th>
                            <th>Parametra vērtības summa</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.metaldata.map(data =>
                            <tr>
                                <td>{data.parameterLv}</td>
                                <td>{data.speciesLv}</td>
                                <td>{data.individuals}</td>
                                <td>{data.value.toFixed(2)} {data.units}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }

    render() {
        let contents = this.renderTable();

        return (
            <div>
                <h1>Metāli pa sugām</h1>
                {contents}
            </div>
        );
    }
}
