import React from "react";

interface SearchResultsLoadingProps {
    message: string;
}
export const SearchResultsLoading: React.FC<SearchResultsLoadingProps> = (
    props
) => {
    return <div>{props.message}</div>;
};
