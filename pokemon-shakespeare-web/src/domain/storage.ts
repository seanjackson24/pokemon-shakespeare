import type { Pokemon } from "../types/Pokemon";

const storageKey = "favourites";

export const getPokemon = (): Pokemon[] => {
    const localStore = localStorage.getItem(storageKey);
    if (!localStore) {
        return [];
    }
    return JSON.parse(localStore) as Pokemon[];
};

export const addOrUpdatePokemon = (pokemon: Pokemon) => {
    const currentFavorites = getPokemon();
    const existingFavorite = currentFavorites.find(
        (p) => p.name === pokemon.name
    );

    let newFavorites: Pokemon[];
    if (existingFavorite) {
        existingFavorite.description = pokemon.description;
        newFavorites = currentFavorites;
    } else {
        newFavorites = [...currentFavorites, pokemon];
    }

    setPokemonAsFavorites(newFavorites);
};

export const tryRemovePokemon = (pokemon: Pokemon) => {
    const currentFavorites = getPokemon();
    const newFavorites = currentFavorites.filter(
        (p) => p.name !== pokemon.name
    );
    setPokemonAsFavorites(newFavorites);
};

const setPokemonAsFavorites = (newFavorites: Pokemon[]) => {
    localStorage.setItem(storageKey, JSON.stringify(newFavorites));
};
