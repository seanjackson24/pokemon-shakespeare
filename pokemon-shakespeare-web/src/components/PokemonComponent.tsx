import React from "react";

import type { Pokemon } from "../types/Pokemon";

export const PokemonComponent: React.FC<Pokemon> = (props) => {
    return (
        <div className="pokemon">
            <div className="pokemon-name">{props.name}</div>
            <div className="pokemon-description">{props.description}</div>
        </div>
    );
};
