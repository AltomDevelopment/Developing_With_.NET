import React from 'react-redux';
import logo from './logo.svg';
import './App.css';
import { store } from "./actions/store";
import { Provider } from "redux";
import DCandidates from './components/DCandidates';
import { Container } from "@material-ui/core";
import { ToastProvider } from "react-toast-notifications";

function App() {
  return (
    <Provider store={store}>
      <ToastProvider autoDismiss={true}>
      <Container maxwidth="lg">
        <DCandidates></DCandidates>
      </Container>
        <DCandidateForm></DCandidateForm>
      </ToastProvider>    
    </Provider>
  );
}

export default App;
