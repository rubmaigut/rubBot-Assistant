import React from "react";
import { faPaperPlane } from "@fortawesome/free-regular-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

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
    <form onSubmit={handleSubmit} className="w-96 flex items-center p-4 absolute bottom-11">
      <textarea
        placeholder="Write your message here"
        value={message}
        onChange={(e) => setMessage(e.target.value)}
        className="resize-none h-10 overflow-hidden p-2 border-2 border-gray-300 rounded-lg mr-4 text-primary-font flex-1 min-h-12 max-h-32"
      />
      <button type="submit" className="p-2">
      <FontAwesomeIcon icon={faPaperPlane} className="w-6 text-secondary-dark" />
      </button>
    </form>
  );
};
