import React from "react";
import type { Message } from "./Message";

export const EmptyFavourites: React.FC<Message> = (props) => {
    return <div>{props.message}</div>;
};
