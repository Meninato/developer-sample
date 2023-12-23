import React from "react";
import "./UserMenu.css";
import { useAuth } from './hooks/use-auth';

const UserMenu = () => {
  const { user } = useAuth();

  return (
    <nav className="user-menu">
      <ul className="menu">
          <li><a className="button" href="#">{user != null ? `Welcome back, ${user.name}` : "You are not logged in"}</a></li>
      </ul>
    </nav>
  );
}

export default UserMenu;