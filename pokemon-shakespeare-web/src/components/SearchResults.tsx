import type { Pokemon } from "../types/Pokemon";
import { EmptySearchResults } from "./EmptySearchResults";
import React, { useCallback, useContext } from "react";
import { addOrUpdatePokemon } from "../domain/storage";
import { PokemonComponent } from "./PokemonComponent";
import { AppContext } from "../domain/FavouritePokemonStoreContext";
import { Actions } from "../domain/reducers";
import { FavStar } from "./FavStar";

export interface SearchResultProps {
    searchResult?: Pokemon;
    emptySearchResultsMessage: string;
}
export const SearchResult: React.FC<SearchResultProps> = (props) => {
    const { searchResult: searchResults, emptySearchResultsMessage } = props;
    const state = useContext(AppContext);

    if (!searchResults) {
        return <EmptySearchResults message={emptySearchResultsMessage} />;
    }
    const onAddToFavourites = useCallback(() => {
        addOrUpdatePokemon(searchResults);
        state.dispatch({ type: Actions.AddFavourite, payload: searchResults });
    }, [searchResults]);
    return (
        <div className="search-result">
            <div onClick={onAddToFavourites} className="favourite-button">
                <FavStar isSelected={false} />
            </div>
            <PokemonComponent {...searchResults} />
        </div>
    );
};
