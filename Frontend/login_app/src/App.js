import React, { useState } from "react";
import './App.css';
import LoginForm from './LoginForm';
import LoginAttemptList from './LoginAttemptList';
import { AuthProvider } from "./hooks/use-auth";
import UserMenu from "./UserMenu";

const App = () => {

  return (
    <div className="App">
      <AuthProvider>
        <UserMenu />
        <LoginForm />
        <LoginAttemptList />
      </AuthProvider>
    </div>
  );
};

export default App;
