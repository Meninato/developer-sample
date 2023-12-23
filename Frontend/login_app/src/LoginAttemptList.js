import React, { useState, useMemo} from "react";
import "./LoginAttemptList.css";
import { useAuth } from "./hooks/use-auth";

const LoginAttempt = (props) => <li {...props}>{props.children}</li>;

const LoginAttemptList = (props) => {
	const { attempts } = useAuth();
	const [search, setSearch] = useState("");

	const filteredUsers = useMemo(() => {
    if (search) {
      return attempts.filter(
        (item) =>
          item
            .toLowerCase()
            .indexOf(search.toLocaleLowerCase()) > -1
      );
    }
    return attempts;
  }, [search, attempts]);

	return (
			<div className="Attempt-List-Main">
				<p>Recent activity</p>
					<input type="input" placeholder="Filter..." value={search} onChange={ e => setSearch(e.target.value )} />
				<ul className="Attempt-List">
					{filteredUsers.length > 0 ? filteredUsers.map((item, index) => <LoginAttempt key={index}>{item}</LoginAttempt>) : <div></div>}
				</ul>
			</div>
		);
	}

export default LoginAttemptList;