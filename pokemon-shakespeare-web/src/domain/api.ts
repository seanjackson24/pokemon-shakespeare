export const searchPokemon = async <T>(searchValue: string) => {
    const response = await fetch(
        `https://localhost:5001/search-pokemon?name=${searchValue}`
    );
    if (!response.ok) {
        throw new Error("Unable to find pokemon");
    }
    const json = await response.json();
    return json as T;
};
