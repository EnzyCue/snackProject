import "./App.css";

function App() {
  return (
    <>
      {/* Root background */}
      <div className="flex flex-row h-full bg-color">
        {/* First left half of screen */}
        <div className="flex flex-col justify-center grow">
          {/* Content info */}
          <div className="bg-cyan-300">
            <h1>Snack App</h1>
            <div>hello2</div>
          </div>
        </div>
        {/* First Right half of screen */}
        <div className="flex flex-col justify-center grow">
          <div>hello</div>
        </div>
      </div>
    </>
  );
}

export default App;
