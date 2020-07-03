import type { Message } from "./Message";

export const EmptySearchResults: React.FC<Message> = (props) => {
    return <div>{props.message}</div>;
};
