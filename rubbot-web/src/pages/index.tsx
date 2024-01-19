import { Inter } from "next/font/google";
import Footer from "../components/Footer";
import Header from "../components/Header";
import RubBotPopup from "../components/RubBot-Popup";
import MyWeekCalendar from "../components/Week-Calendar";

const inter = Inter({ subsets: ["latin"] });

export default function Home() {
  const events = [
    { time: "8:00 AM", title: "Magic Write", icon: "🪄" },
    { time: "10:00 AM", title: "Research Business", icon: "🔍" },
    // ...more events
  ];
  return (
    <main className="w-[410px] bg-primary-bg h-[90%] flex flex-col items-center justify-between rounded-xl">
      <div className="w-full flex justify-between">
        <Header logo="/secondBrainLogo.svg" className="px-3" />
      </div>
      <div className="w-full h-full rounded shadow-lg overflow-auto">
        <div className="flex flex-col w-full h-full px-4 rounded">
          <RubBotPopup
            title={"Welcome Maide"}
            message={
              "This is how your day looks so far!. Please write me if your need my help!"
            }
          />
          <div className="mt-4 rounded shadow-lg flex justify-between h-[82%]">
            <MyWeekCalendar />
          </div>
        </div>
      </div>
      <Footer />
    </main>
  );
}
