import React, { useState, useRef, FormEvent, useContext } from "react";
import type { Pokemon } from "../types/Pokemon";
import { LoadingState } from "../types/LoadingState";
import { searchPokemon } from "../domain/api";
import { SearchResultsLoading } from "./SearchResultsLoading";
import { SearchResultsFailure } from "./SearchResultsFailure";
import { SearchResult } from "./SearchResults";
import { DisplayTextContext } from "../domain/DisplayText";

export const PokemonSearch: React.FC<{}> = (props) => {
    const displayText = useContext(DisplayTextContext);

    const { searchLabel, loadingMessage, failureMessage } = displayText;
    const [results, setResults] = useState<Pokemon>();
    const [loadingState, setLoadingState] = useState(LoadingState.NotLoaded);
    const inputRef = useRef<HTMLInputElement>(null);

    const onSearch = (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        setLoadingState(LoadingState.Loading);
        (async () => {
            try {
                const searchTerm = inputRef.current?.value;
                if (!searchTerm) {
                    console.error("Unable to obtain ref to search box");
                    setLoadingState(LoadingState.Failure);
                } else {
                    const searchResults = await searchPokemon<Pokemon>(
                        searchTerm
                    );
                    setResults(searchResults);
                    setLoadingState(LoadingState.Success);
                }
            } catch (ex) {
                setLoadingState(LoadingState.Failure);
            }
        })();
    };
    return (
        <div className="pokemon-search">
            <form onSubmit={onSearch} className="search-form">
                <label className="search-header" htmlFor="search-field">
                    {searchLabel}
                </label>
                <input
                    ref={inputRef}
                    name="search-field"
                    type="text"
                    className="search-field"
                ></input>
            </form>
            {loadingState === LoadingState.Loading && (
                <SearchResultsLoading message={loadingMessage} />
            )}
            {loadingState === LoadingState.Failure && (
                <SearchResultsFailure message={failureMessage} />
            )}
            {loadingState === LoadingState.Success && results !== undefined && (
                <SearchResult
                    searchResult={results}
                    emptySearchResultsMessage={displayText.emptyResultsMessage}
                />
            )}
        </div>
    );
};
