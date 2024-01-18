import React, { useState } from "react";
import { ChatMessage, ChatMessageType } from "../components/ChatMessage";
import { ChatInput } from "../components/ChatInput";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faChevronLeft } from "@fortawesome/free-solid-svg-icons";
import Image from "next/image";
import Link from "next/link";

const ChatComponent: React.FC = () => {
  const [messages, setMessages] = useState<ChatMessageType[]>([
    {
      text: "Hi there! /add/Work/Task Today at 16.00 meeting with new client. Note: Prepare brochure!",
      isUser: false,
    },
    { text: "Hey, Maide", isUser: true },
    {
      text: "Adding the information now, you can check your board",
      isUser: false,
    },
    { text: "Thank you 😊", isUser: true },
  ]);

  const sendMessage = (newMessage: string) => {
    const newMessages = [...messages, { text: newMessage, isUser: true }];
    setMessages(newMessages);
  };

  return (
    <section className="flex min-h-screen flex-col items-center justify-between md:p-24">
      <div className="max-w-md min-h-[60rem] mx-auto bg-primary-bg p-4 rounded shadow-lg">
        <div className="w-full h-24 flex items-center">
          <Link href="/">
            <FontAwesomeIcon
              icon={faChevronLeft}
              className="w-6 text-secondary-dark"
            />
          </Link>
          <div className="flex items-center">
            <Image
              src="RubBot.svg"
              alt="RubBot.svg"
              className=""
              width={60}
              height={20}
              priority
            />
            <span className="font-semibold text-lg text-primary-font ml-2">
              RubBot
            </span>
          </div>
        </div>
        <span className="w-full flex justify-center text-sm text-primary-font mb-4">
          today
        </span>

        <div className="flex-grow overflow-auto">
          {messages.map((message, index) => (
            <ChatMessage key={index} message={message} />
          ))}
        </div>
        <ChatInput sendMessage={sendMessage} />
      </div>
    </section>
  );
};

export default ChatComponent;
