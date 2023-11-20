import React, { Component } from 'react';
import { format } from 'date-fns'

export class AllData extends Component {
    constructor(props) {
        super(props);
        this.state = { metaldata: [], sortKey: "" };
    }

    componentDidMount() {
        fetch("/Contaminants/ListAll")
            .then(function (response) {
                return response.json();
            })
            .then(items => this.setState({ metaldata: items }));
    }

    renderTable() {
        return (
            <div className='overflow-div'>
                <table className='table table-striped table-bordered table-sm' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th onClick={() => { this.sortTable("id") }}>ID⇕</th>
                            <th onClick={() => { this.sortTable("trip") }}>Paraugu ņemšanas kampaņas kods⇕</th>
                            <th onClick={() => { this.sortTable("longitude") }}>Ģeogrāfiskā Austrumu garuma grādu decimālskaitlis⇕</th>
                            <th onClick={() => { this.sortTable("latitude") }}>Ģeogrāfiskā Ziemeļu platuma grādu decimālskaitlis⇕</th>
                            <th onClick={() => { this.sortTable("datetime") }}>Paraugu vākšanas datums un laiks⇕</th>
                            <th onClick={() => { this.sortTable("station") }}>Stacijas kods⇕</th>
                            <th onClick={() => { this.sortTable("bottdepthm") }}>Paraugu ņemšanas stacijas dziļums metros⇕</th>
                            <th onClick={() => { this.sortTable("sampleid") }}>Unikāls parauga identifikācijas numurs⇕</th>
                            <th onClick={() => { this.sortTable("parameterLv") }}>Paraugam noteiktie parametri⇕</th>
                            <th onClick={() => { this.sortTable("tissue") }}>Audi, kuriem noteikts attiecīgais parametrs⇕</th>
                            <th onClick={() => { this.sortTable("speciesLv") }}>Zivju suga⇕</th>
                            <th onClick={() => { this.sortTable("individuals") }}>Paraugā apvienots īpatņu skaits⇕</th>
                            <th onClick={() => { this.sortTable("value") }}>Iegūtā parametra vērtība⇕</th>
                            <th onClick={() => { this.sortTable("quality") }}>Attiecīgās mērījuma vērtības kvalitātes karogs⇕</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.metaldata.map(data =>
                            <tr>
                                <td>{ data.id }</td>
                                <td>{data.trip}</td>
                                <td>{data.longitude.toFixed(6)}</td>
                                <td>{data.latitude.toFixed(6)}</td>
                                <td>{format(Date.parse(data.datetime), 'dd.MM.yyyy')}</td>
                                <td>{data.station}</td>
                                <td>{data.bottdepthm}</td>
                                <td>{data.sampleid}</td>
                                <td>{data.parameterLv}</td>
                                <td>{data.tissue}</td>
                                <td>{data.speciesLv}</td>
                                <td>{data.individuals}</td>
                                <td>{data.value.toFixed(2)} {data.units}</td>
                                <td>{data.quality}</td>
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
                <h1>Metāli Baltijas jūras un Rīgas līča zivīs</h1>
                {contents}
            </div>
        );
    }

    sortTable(key) {
        // if key matches last sort key, order by desc, else order by asc
        if (this.state.sortKey === key) {
            this.state.metaldata.sort((a, b) => b[key] > a[key] ? 1 : -1);
            this.setState({ metaldata: this.state.metaldata, sortKey: "" });
        } else {
            this.state.metaldata.sort((a, b) => a[key] > b[key] ? 1 : -1);
            this.setState({ metaldata: this.state.metaldata, sortKey: key });
        }
    }
}
