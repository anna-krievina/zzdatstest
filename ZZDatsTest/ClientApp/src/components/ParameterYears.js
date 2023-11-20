import React, { Component } from 'react';
import { format } from 'date-fns'
export class ParameterYears extends Component {
    constructor(props) {
        super(props);
        this.state = { metaldata: [] };
    }

    componentDidMount() {
        fetch("/Contaminants/ParametersInYears")
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
                            <th>Gads</th>
                            <th>Paraugam noteiktie parametri</th>
                            <th>Vidējā parametra vērtība</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.metaldata.map(data =>
                            <tr>
                                <td>{format(Date.parse(data.datetime), 'yyyy')}</td>
                                <td>{data.parameterLv}</td>
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
                <h1>Parametru vērtības gados</h1>
                {contents}
            </div>
        );
    }
}
