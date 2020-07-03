import React, { useReducer, useContext } from "react";
import { EmptyFavourites } from "./EmptyFavourites";
import type { Pokemon } from "../types/Pokemon";
import { FavouriteItem } from "./FavouriteItem";
import { AppContext } from "../domain/FavouritePokemonStoreContext";
import { Actions } from "../domain/reducers";
import { DisplayTextContext } from "../domain/DisplayText";

export interface FavouritesListProps {
    favourites: Pokemon[];
}
export const FavouritesList: React.FC<FavouritesListProps> = (props) => {
    const { favourites } = props;
    const displayText = useContext(DisplayTextContext);

    const state = useContext(AppContext);

    const onRemoveFromFavourites = (pokemon: Pokemon) => {
        state.dispatch({ type: Actions.RemoveFavourite, payload: pokemon });
    };

    return (
        <div className="favourites">
            <div className="favourites-title">
                {displayText.favouritesTitle}
            </div>
            {!favourites.length && (
                <EmptyFavourites message={displayText.emptyFavourites} />
            )}
            <ul className="favourites-list">
                {favourites.map((f) => (
                    <FavouriteItem
                        key={f.name}
                        pokemon={f}
                        onRemoveFromFavourites={onRemoveFromFavourites}
                    />
                ))}
            </ul>
        </div>
    );
};
