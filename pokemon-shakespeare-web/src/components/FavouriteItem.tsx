import React from "react";

import type { Pokemon } from "../types/Pokemon";
import { PokemonComponent } from "./PokemonComponent";
import { FavStar } from "./FavStar";

interface FavouriteItemProps {
    icon?: string;
    pokemon: Pokemon;
    onRemoveFromFavourites: (pokemon: Pokemon) => void;
}
export const FavouriteItem: React.FC<FavouriteItemProps> = (props) => {
    const { pokemon, onRemoveFromFavourites } = props;
    return (
        <li key={pokemon.name} className="favourite-item">
            <span onClick={() => onRemoveFromFavourites(pokemon)}>
                <FavStar isSelected={true} />
            </span>
            <PokemonComponent
                name={pokemon.name}
                description={pokemon.description}
            />
        </li>
    );
};
