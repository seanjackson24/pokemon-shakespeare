import React, { createContext, useReducer, Dispatch } from "react";
import { favouritePokemonReducer, FavouritePokemonActions } from "./reducers";
import type { Pokemon } from "../types/Pokemon";
import { getPokemon } from "./storage";

type InitialState = {
    favouritePokemon: Pokemon[];
};

const initialState: InitialState = {
    favouritePokemon: getPokemon(),
};

const AppContext = createContext<{
    state: InitialState;
    dispatch: Dispatch<FavouritePokemonActions>;
}>({
    state: initialState,
    dispatch: () => null,
});

const appReducer = (
    { favouritePokemon }: InitialState,
    action: FavouritePokemonActions
) => ({
    favouritePokemon: favouritePokemonReducer(favouritePokemon, action),
});

const AppProvider: React.FC = ({ children }) => {
    const [state, dispatch] = useReducer(appReducer, initialState);

    return (
        <AppContext.Provider value={{ state, dispatch }}>
            {children}
        </AppContext.Provider>
    );
};

export { AppProvider, AppContext };
