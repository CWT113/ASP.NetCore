<template>
  <input type="text" v-model="state.userMessage" @keypress="txtMsgOnkeypress" />

  <div>
    <ul>
      <li v-for="(msg, index) in state.message" :key="index">{{ msg }}</li>
    </ul>
  </div>
</template>

<script setup>
import * as signalR from "@microsoft/signalr";
import { onMounted, reactive } from "vue";

let connection;
const state = reactive({
  userMessage: "",
  message: []
});

const txtMsgOnkeypress = async (e) => {
  if (e.keyCode != 13) return;
  await connection.invoke("SendPublicMsg", state.userMessage);
  state.userMessage = "";
};

onMounted(async () => {
  connection = new signalR.HubConnectionBuilder()
    // 不禁用协商
    // .withUrl("https://localhost:7167/myhub")
    // SignalR的协商协议 -- 禁用协商
    .withUrl("https://localhost:7167/myhub", {
      skipNegotiation: true,
      transport: signalR.HttpTransportType.WebSockets
    })
    .withAutomaticReconnect()
    .build();
  await connection.start();
  connection.on("PublicMsgReceived", (msg) => {
    state.message.push(msg);
  });
});
</script>

<style></style>
