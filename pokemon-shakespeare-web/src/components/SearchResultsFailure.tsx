import React from "react";
import img from "../images/pikachu.png";

interface SearchResultsFailureProps {
    message: string;
}
export const SearchResultsFailure: React.FC<SearchResultsFailureProps> = (
    props
) => {
    return (
        <div className="search-failure">
            {props.message}
            <img
                width="512"
                height="284"
                className="failure-image"
                alt="Fainted Pikachu"
                src={img}
            ></img>
        </div>
    );
};
