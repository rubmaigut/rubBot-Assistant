import Header from "./components/Header";
import RubBotPopup from "./components/RubBot-Popup";

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

        {/* Calendar */}
        <div className="mt-4 p-4 rounded shadow-lg flex justify-between">
          {/* ... */}
        </div>

        {/* Schedule */}
        <div className="mt-4 space-y-2">
          {events.map((event, index) => (
            <div
              key={index}
              className="p-4 rounded shadow-lg flex items-center justify-between"
            >
              <span className="font-bold">{event.time}</span>
              <div className="flex items-center">
                <span className="text-xl">{event.icon}</span>
                <span className="ml-2">{event.title}</span>
              </div>
            </div>
          ))}
        </div>
      </div>
    </main>
  );
}
