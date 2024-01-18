export type ChatMessageType = {
  text: string;
  isUser: boolean;
};

type ChatMessageProps = {
  message: ChatMessageType;
};

export const ChatMessage: React.FC<ChatMessageProps> = ({ message }) => {
  const messageClass = message.isUser
    ? "bg-bot-message-bg float-right"
    : "bg-secondary-bg float-left text-primary-font";
  return (
    <div
      className={`max-w-xs md:max-w-md lg:max-w-lg px-4 py-2 rounded-lg m-2 ${messageClass} clear-both`}
    >
      <p>{message.text}</p>
    </div>
  );
};
