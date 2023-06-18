import {applyMiddleware, combineReducers, legacy_createStore} from "redux";
import thunk from "redux-thunk";
import catalogReducer from "../Reducers/catalogReducer";

let reducers = combineReducers(
    {
        catalogPage: catalogReducer
    }
)

let store = legacy_createStore(reducers, applyMiddleware(thunk));

export default store;