import React, {useContext, createContext, useState} from 'react';
import { AuthUser } from '../models/user-model';

const AuthContext = createContext();

export const AuthProvider = ({children}) => {
  const [user, setUser] = useState(null);
  const [attempts, setAttempts] = useState([]);

  const login = async (username, password) => {
    return new Promise((resolve, reject) => {
      if(username === "admin" && password === "1234") {
        const authUser = new AuthUser("Bob");
        setUser(authUser);
        resolve();
      } else {
        reject("Wrong username or password");
      }
    });
  };

  const logout = async () => {
    setUser(null);
  };
  
  const exposedMethods = { login, logout, user, attempts, setAttempts };

  return (
    <AuthContext.Provider value={exposedMethods}>
      {children}
    </AuthContext.Provider>
  );
}

export const useAuth = () => {
  return useContext(AuthContext);
}