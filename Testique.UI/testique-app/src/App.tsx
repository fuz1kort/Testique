import './App.css';
import AppRouter from "./commonComponents/AppRouter/AppRouter";
import {UserContext} from "./index";
import {observer} from "mobx-react-lite";
import React, {useContext, useEffect} from "react";
import {BrowserRouter} from "react-router-dom";
import loadUser from "./functions/loadUser";

const App = observer(() => {
    const userStore = useContext(UserContext);

    useEffect(() => {
        loadUser()
            .then(user => {
                    if (user !== undefined) {
                        userStore.login(user)
                    }
                }
            )
    }, []);

    return (
        <BrowserRouter>
            <div className="app">
                <div className="app__main">
                    <AppRouter/>
                </div>
            </div>
        </BrowserRouter>
    );
})

export default App;
