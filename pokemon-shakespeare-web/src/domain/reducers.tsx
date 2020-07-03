import type { Pokemon } from "../types/Pokemon";
import { addOrUpdatePokemon, getPokemon, tryRemovePokemon } from "./storage";

type ActionMap<M extends { [index: string]: any }> = {
    [Key in keyof M]: M[Key] extends undefined
        ? {
              type: Key;
          }
        : {
              type: Key;
              payload: M[Key];
          };
};

export enum Actions {
    AddFavourite = "AddFavourite",
    RemoveFavourite = "RemoveFavourite",
}

type FavouritePokemonPayload = {
    [Actions.AddFavourite]: Pokemon;
    [Actions.RemoveFavourite]: Pokemon;
};

export type FavouritePokemonActions = ActionMap<
    FavouritePokemonPayload
>[keyof ActionMap<FavouritePokemonPayload>];

export const favouritePokemonReducer = (
    state: Pokemon[],
    action: FavouritePokemonActions
) => {
    switch (action.type) {
        case Actions.AddFavourite:
            addOrUpdatePokemon(action.payload);
            return getPokemon();
        case Actions.RemoveFavourite:
            tryRemovePokemon(action.payload);
            return getPokemon();
        default:
            return getPokemon();
    }
};
