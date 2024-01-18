import Footer from "./components/Footer";
import Header from "./components/Header";
import RubBotPopup from "./components/RubBot-Popup";
import MyWeekCalendar from "./components/Week-Calendar";

export default function Home() {
  const events = [
    { time: "8:00 AM", title: "Magic Write", icon: "🪄" },
    { time: "10:00 AM", title: "Research Business", icon: "🔍" },
    // ...more events
  ];
  return (
    <main className="flex min-h-screen flex-col items-center justify-between md:p-24">
      <div className="max-w-md mx-auto bg-primary-bg p-4 rounded shadow-lg">
        <div className="flex items-center justify-between">
          <Header logo="/secondBrainLogo.svg" />
        </div>
        <div className="py-4 rounded">
          <RubBotPopup
            title={"Welcome Maide"}
            message={
              "This is how your day looks so far!. Please write me if your need my help!"
            }
          />
        </div>

        <div className="mt-4 rounded shadow-lg flex justify-between">
         <MyWeekCalendar />
        </div>
      <Footer/>
      </div>
    </main>
  );
}
