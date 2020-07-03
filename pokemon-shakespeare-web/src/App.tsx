import React, { useState, useEffect, useContext } from "react";
import type { Pokemon } from "./types/Pokemon";

import { FavouritesList } from "./components/FavouritesList";
import { PokemonSearch } from "./components/PokemonSearch";
import { getPokemon } from "./domain/storage";
import { AppContext } from "./domain/FavouritePokemonStoreContext";
import { DisplayTextContext } from "./domain/DisplayText";

export const App: React.FC<{}> = () => {
    const displayText = useContext(DisplayTextContext);

    const [favorites, setFavorites] = useState<Pokemon[]>([]);
    // listen to local storage changes on another tab
    useEffect(() => {
        window.addEventListener("storage", () => setFavorites(getPokemon()));
    }, []);
    const state = useContext(AppContext);

    useEffect(() => {
        setFavorites(state.state.favouritePokemon);
    }, [state]);

    return (
        <div className="app-root">
            <h1>{displayText.title}</h1>

            <div className="search-favourites">
                <PokemonSearch />
                <FavouritesList favourites={favorites} />
            </div>
        </div>
    );
};
