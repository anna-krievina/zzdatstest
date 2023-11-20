import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class Home extends Component {
    render() {
        return (
            <div>
                <Link to="/all-data">Metāli Baltijas jūras un Rīgas līča zivīs</Link>
                <h3>Atskaites</h3>
                <ol>
                    <li><Link to="/metals">Metāli pa sugām</Link></li>
                    <li><Link to="/years">Parametru vērtības gados</Link></li>
                </ol>
            </div>
        );
    }
}
