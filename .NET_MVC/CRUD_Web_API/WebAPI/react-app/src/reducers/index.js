import { combineReducers } from "redux"; //Take the current state and an action as arguments, and return a new state result.
import { dCandidate } from "./dCandidate";

export const reducers = combineReducers({ //Combine Reducers turns an object whose values are different reducing functions into a single reducing function you can pass to createStore
    dCandidate
})