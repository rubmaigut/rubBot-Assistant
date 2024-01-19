import React, { useEffect, useState } from "react";
import { ChatMessage, ChatMessageType } from "../components/ChatMessage";
import { ChatInput } from "../components/ChatInput";
import { faChevronLeft } from "@fortawesome/free-solid-svg-icons";
import Image from "next/image";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Link from "next/link";
import { addDays, addHours, setHours, setMinutes } from "date-fns";

type CalendarEvent = {
  start: Date;
  end: Date;
  title: string;
  desc?: string;
};

const ChatComponent: React.FC = () => {
  const [messages, setMessages] = useState<ChatMessageType[]>([
    { text: "Hello! How can I assist you today?", isUser: false },
  ]);

  const [events, setEvents] = useState<CalendarEvent[]>([]);

  useEffect(() => {}, [messages]);

  const createEventFromMessage = (message: string) => {
    console.log("Processing message for event creation:", message);
    const match = message.match(/\/add-(\w+)-(\w+) (.+)/);
    if (match) {
      const [, category, task, details] = match;
      const timeMatch = details.match(/(\d{1,2}) tomorrow/);
      if (timeMatch) {
        const [_, time] = timeMatch;
        const hours = parseInt(time, 10);
        const startDate = setHours(addDays(new Date(), 1), hours);
        const endDate = addHours(startDate, 1); // Assuming 1 hour duration

        const newEvent = {
          start: startDate,
          end: endDate,
          title: `${category}: ${task}`,
          desc: details,
        };

        setTimeout(() => {
          setMessages((prevMessages) => [
            ...prevMessages,
            {
              text: `Event '${newEvent.title}' added successfully.`,
              isUser: false,
            },
          ]);
        }, 2000);
      } else {
        console.log("No match for event creation command2.");
       setMessages((prevMessages) => [
          ...prevMessages,
          {
            text: "Sorry, I couldn't understand the time format. Please use 'HH tomorrow'.",
            isUser: false,
          },
        ]);
      }
    } else {
      console.log("No match for event creation command2.");
     setMessages((prevMessages) => [
        ...prevMessages,
        {
          text: "Sorry, I didn't understand that. Please use the format /add-Category-Task Description.",
          isUser: false,
        },
      ]);
    }
  };

  const generateBotResponse = (userMessage: string) => {
    console.log("Generating response for:", userMessage);
    if (userMessage.toLowerCase().includes("/add")) {
      createEventFromMessage(userMessage);
    } else {
      console.log("Unrecognized command.");
      return "I'm not sure how to respond to that. Can you try a different command?";
    }
  };

  const sendMessage = (newMessage: string, isUser: boolean = true) => {
    setMessages((prevMessages) => [
      ...prevMessages,
      { text: newMessage, isUser: isUser },
    ]);

    if (isUser) {
      const botResponse = generateBotResponse(newMessage);
      if (botResponse) {
        setTimeout(() => {
          setMessages((prevMessages) => [
            ...prevMessages,
            { text: botResponse, isUser: false },
          ]);
        }, 5000);
      }
    }
  };

  return (
    <section className="w-[410px] bg-primary-bg h-[90%] flex flex-col items-center justify-between rounded-xl px-4">
      <div className="w-full flex flex-col">
        <div className="w-full h-24 flex items-center ">
          <Link href="/">
            <FontAwesomeIcon
              icon={faChevronLeft}
              className="w-8 text-secondary-dark mr-2"
            />
          </Link>
          <Image
            src="/RubBot.svg"
            alt="RubBot.svg"
            width={60}
            height={20}
            priority
          />
          <span className="font-semibold text-lg text-primary-font ml-2">
            RubBot
          </span>
        </div>
        <span className=" w-full flex items-center justify-center text-sm text-center text-primary-font mb-4">
          Today
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
