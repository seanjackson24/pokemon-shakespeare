import React from "react";

export const defaultDisplayText = {
    title: "Pokemon Shakespeare Translator",
    searchLabel: "Search",
    loadingMessage: "Loading....",
    failureMessage: "Oh no! Something went wrong finding your pokemon!",
    emptyResultsMessage: "No results found for that term...",
    favouritesTitle: "Your Favourites:",
    emptyFavourites:
        "No favourite Pokemon yet. Search for one above and click the star...",
};
export const DisplayTextContext = React.createContext(defaultDisplayText);
