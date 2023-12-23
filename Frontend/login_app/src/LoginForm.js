import React from "react";
import './LoginForm.css';
import { useAuth } from './hooks/use-auth';

const LoginForm = (props) => {
	const { login, logout, setAttempts } = useAuth();

	const handleSubmit = (e) => {
		e.preventDefault();
		const {username, password } = e.target.elements;

		login(username.value, password.value)
			.then(() => setAttempts([]))
			.catch((err) => {
					console.log(err);
					setAttempts(prevState => ([...prevState, `Wrong ${username.value}`]));
					logout();
				});
	}

	return (
		<form onSubmit={handleSubmit} className="form">
			<h1>Login</h1>
			<label htmlFor="name">Name</label>
			<input type="text" name="username" />
			<p><strong>Username: admin</strong></p>
			<label htmlFor="password">Password</label>
			<input type="password" name="password" />
			<p><strong>Pass: 1234</strong></p>
			<button type="submit">Continue</button>
		</form>
	)
}

export default LoginForm;