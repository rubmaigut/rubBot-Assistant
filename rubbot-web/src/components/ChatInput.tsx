
import { faPaperPlane } from "@fortawesome/free-regular-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import React from "react";

type ChatInputProps = {
  sendMessage: (message: string) => void;
};

export const ChatInput: React.FC<ChatInputProps> = ({ sendMessage }) => {
  const [message, setMessage] = React.useState("");

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    sendMessage(message);
    setMessage("");
  };

  return (
    <form onSubmit={handleSubmit} className="flex w-[27rem] items-center p-4 fixed bottom-80">
      <input
        type="text"
        placeholder="Write your message here"
        value={message}
        onChange={(e) => setMessage(e.target.value)}
        className="flex-1 p-2 border-2 border-gray-300 rounded-lg mr-4"
      />
      <button type="submit" className="p-2">
      <FontAwesomeIcon icon={faPaperPlane} className="w-6 text-secondary-dark" />
      </button>
    </form>
  );
};
