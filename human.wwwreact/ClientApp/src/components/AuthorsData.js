import React, { Component } from 'react';

export class AuthorsData extends Component {
    static displayName = AuthorsData.name;

    constructor(props) {
        super(props);
        this.state = { authors: [], loading: true };
    }

    componentDidMount() {
        this.populateAuthorData();
    }

    static renderAuthorsTable(people) {
        //console.log(people);
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>

                        <th>FirstName</th>
                        <th>LastName</th>
                        <th>Email</th>
                        <th></th>
                    </tr>
                </thead>

                <tbody>
                    {
                        authors.map(p =>
                            <tr key={p.id}>
                                <td>{p.FirstName}</td>
                                <td>{p.LastName}</td>
                                <td>{p.Email}</td>
                                <td>
                                    <a className="btn btn-warning btn-sm">Edit</a>&nbsp;
                                    <a className="btn btn-danger btn-sm">Delete</a>
                                </td>
                            </tr>
                        )}

                </tbody>

            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : AuthorsData.renderAuthorsTable(this.state.authors);

        return (
            <div>
                <h1 id="tableLabel">Authors Data</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateAuthorsData() {
        const response = await fetch('https://localhost:7129/authors');
        const data = await response.json();
        console.log(data);
        this.setState({ authors: data, loading: false });
    }
}
