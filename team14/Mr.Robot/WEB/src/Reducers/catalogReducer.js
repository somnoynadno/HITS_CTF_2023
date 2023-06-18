import {catalogApi} from "../Api/catalogAPI";

const LOAD_DATA = "LOAD_DATA"
const CHECK_PASS = "CHECK_PASS"
const ADD_DISH = "ADD_DISH"


let inititalState = {
    data: [],
    dishAdding: false,
    isLogged: false
}


const catalogReducer = (state = inititalState, action) => {
    let newState = {...state};
    switch (action.type){
        case LOAD_DATA:
            newState.data = {...action.data.data}
            return newState;
        case CHECK_PASS:
            console.log(action.data)
            newState.isLogged = action.data.status;
            return newState;
        case ADD_DISH:
            newState.dishAdding = action.data.status;
            return newState;
        default:
            return newState;

    }
}

export function catalogActionCreator(data){
    return {type: LOAD_DATA, data:data}
}

export function catalogThunkCreator(body){
    return (dispatch) => {
        catalogApi.getPayload(body).then( (data) => {
            dispatch(catalogActionCreator(data))
        })
    }
}
export function addDishActionCreator(data){
    return {type: ADD_DISH, data:data}
}

export function addDishThunkCreator(body, category){
    return (dispatch) => {
        catalogApi.addDish(body,category).then( (data) => {
            dispatch(addDishActionCreator(data))
        })
    }
}
export function checkPassActionCreator(data){
    return {type: CHECK_PASS, data:data}
}

export function checkPassThunkCreator(body){
    return (dispatch) => {
        catalogApi.checkPassword(body).then( (data) => {
            dispatch(checkPassActionCreator(data))
        })
    }
}


export default catalogReducer;