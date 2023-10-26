import {createStore, applyMiddleware, compose} from "react-redux";//Allows us to dispatch actions manually, which gives us the power to incorporate some logic or run some asynchronous code before dispatching an action.
import thunk from "redux-thunk"; //Allows us to make asynchronos calls 
import { reducers } from "../reducers";//Take the current state and an action as arguments, and return a new state result.

export const store = createStore(//The Redux store is the main, central bucket which stores all the states of an application. 
                                 //It should be considered and maintained as a single source of truth for the state of the application.
    reducers,
    compose(//Used when you want to pass multiple store enhancers to the store
        applyMiddleware(thunk),
        window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()//Added to use the React Dev Tools Extension
    )
)