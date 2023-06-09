import React, { Component } from 'react';

export class NameForm extends Component {

    constructor() {

        this.state = {
            formControls: {
                email: {
                    value: ''
                },
                name: {
                    value: ''
                },
                password: {
                    value: ''
                }
            }
        }

    }

    changeHandler = event => {

        const name = event.target.name;
        const value = event.target.value;

        this.setState({
            formControls: {
                ...this.state.formControls,
                [name]: {
                    ...this.state.formControls[name],
                    value
                }
            }
        });
    }


    render() {
        return (
            <form>

                <input type="email"
                    name="email"
                    value={this.state.formControls.email.value}
                    onChange={this.changeHandler}
                />

                <input type="text"
                    name="name"
                    value={this.state.formControls.name.value}
                    onChange={this.changeHandler}
                />

                <input type="password"
                    name="password"
                    value={this.state.formControls.password.value}
                    onChange={this.changeHandler}
                />

            </form>
        );
    }

}


//export default NameForm;

//import React, { Component } from 'react';

//export class NameForm extends Component {
//    constructor() {
//        this.state = {
//            email: ''
//        }
//    }

//    changeHandler = event => {
//        this.setState({
//            email: event.target.value
//        });
//    }

//    render() {
//        return (
//            <form>
//                <input type="email"
//                    name="email"
//                    value={this.state.email}
//                    onChange={this.changeHandler}
//                />
//            </form>
//        );
//    }
//}
    /*state = { companyName: 'yes' };*/
    //handleSubmit = async (event) => {
    //    event.preventDefault();
    //    const resp = await axios.get(`https://api.github.com/users/${this.state.companyName}`);
    //    this.props.onSubmit(resp.data);
    //    this.setState({ companyName: '' });
    //};

    //constructor(props) {
    //    console.log(props);
    //    super(props);
    //    this.handleSubmit = this.handleSubmit.bind(this);
    //}

    //handleSubmit(e) {
    //    //alert('The value is: ' + this.input.value);
    //    console.log(this.input);
    //    e.preventDefault();
    //}

    //render() {
    //    return (
    //        <form onSubmit={this.handleSubmit}>
    //            <label>
    //                Name:
    //                <input type="text" ref={(input) => this.input = input} />
    //            </label>
    //            <input type="submit" value="Submit" />
    //            <input
    //                type="text"
    //                value={this.state.companyName}
    //                placeholder="Enter Company Name"
    //                required
    //            />
    //        </form>
    //    );
    //}
