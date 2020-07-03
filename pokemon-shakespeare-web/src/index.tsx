import React from "react";
import ReactDOM from "react-dom";
import { App } from "./App";
import { AppProvider } from "./domain/FavouritePokemonStoreContext";
import { DisplayTextContext, defaultDisplayText } from "./domain/DisplayText";

ReactDOM.render(
    <React.StrictMode>
        <AppProvider>
            <DisplayTextContext.Provider value={defaultDisplayText}>
                <App />
            </DisplayTextContext.Provider>
        </AppProvider>
    </React.StrictMode>,
    document.getElementById("root")
);

// Hot Module Replacement (HMR) - Remove this snippet to remove HMR.
// Learn more: https://www.snowpack.dev/#hot-module-replacement
if (import.meta.hot) {
    import.meta.hot.accept();
}
