import React, { useState } from 'react';
import { ChatMessage, ChatMessageType } from '../components/ChatMessage';
import { ChatInput } from '../components/ChatInput';

const ChatComponent: React.FC = () => {
  const [messages, setMessages] = useState<ChatMessageType[]>([
    { text: "Hi there! /add/Work/Task Today at 16.00 meeting with new client. Note: Prepare brochure!", isUser: false },
    { text: "Hey, Maide", isUser: true },
    { text: "Adding the information now, you can check your board", isUser: false },
    { text: "Thank you 😊", isUser: true },
  ]);

  const sendMessage = (newMessage: string) => {
    const newMessages = [...messages, { text: newMessage, isUser: true }];
    setMessages(newMessages);
  };

  return (
    <div className="flex flex-col w-full">
      <div className="flex-grow overflow-auto">
        {messages.map((message, index) => (
          <ChatMessage key={index} message={message} />
        ))}
      </div>
      <ChatInput sendMessage={sendMessage} />
    </div>
  );
};

export default ChatComponent;
