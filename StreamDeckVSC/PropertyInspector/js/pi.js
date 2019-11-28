let socket = null;
let inspector = {};

function connectElgatoStreamDeckSocket(inPort, inUUID, inRegisterEvent, inInfo, inActionInfo) {
  inspector.registerEvent = inRegisterEvent;
  inspector.port = inPort;
  inspector.uuid = inUUID;

  connect();
}

function connect() {
  socket = new WebSocket("ws://127.0.0.1:" + inspector.port);
  socket.onopen = _ => connectedToPropertyInspector();
  socket.onmessage = message => messageReceived(message);
  socket.onclose = _ => connect();
}

function connectedToPropertyInspector() {
  registerPropertyInspector();

  requestSettings();

  registerChangeDetection();
}

function messageReceived(message) {
  const json = JSON.parse(message.data);

  if (json.event === "didReceiveSettings") {
    settingsReceived(json.payload.settings);
  }
}

function registerPropertyInspector() {
  socket.send(
    JSON.stringify({
      event: inspector.registerEvent,
      uuid: inspector.uuid
    })
  );
}

function isConnectedToPropertyInspector() {
  return socket && socket.readyState === 1;
}

function registerChangeDetection() {
  getInputs().forEach(element => element.addEventListener("input", () => saveSettings()));
}

function getInputs() {
  return Array.from(document.querySelectorAll(".sdpi-item-value")).map(element => {
    if (element.tagName !== "INPUT") {
      return element.querySelector("input");
    }

    return element;
  });
}

function requestSettings() {
  if (isConnectedToPropertyInspector()) {
    socket.send(
      JSON.stringify({
        event: "getSettings",
        context: inspector.uuid
      })
    );
  }
}

function settingsReceived(settings) {
  Object.entries(settings).forEach(([key, value]) => {
    const element = document.getElementById(key);

    if (element) {
      if (element.type === "checkbox") {
        element.checked = value;
      } else {
        element.value = value;
      }
    }
  });
}

function saveSettings() {
  if (isConnectedToPropertyInspector()) {
    let payload = {};

    getInputs().forEach(element => {
      if (element.type === "checkbox") {
        payload[element.id] = element.checked ? true : false;
      } else {
        payload[element.id] = element.value;
      }
    });

    socket.send(
      JSON.stringify({
        event: "setSettings",
        context: inspector.uuid,
        payload
      })
    );
  }
}
