import axios from 'axios';
import {BASE_URL} from "./url";


const instance = axios.create({
    baseURL: BASE_URL,
});
axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';

function getData(param){
    return instance.get(`/catalog/${param}`)
        .then(response => {
            if (response.status === 200){
                return {
                    status: response.status,
                    data: response.data
                };
            }
        })
        .catch(error => {
            return {
                status: error.status,
                message: error.response
            };
        })
}

function postDish(body, category){
    return instance.post(`/dish/add/${category}`, body)
        .then(response => {
            if (response.status === 200){
                return {
                    status: response.status,
                    flag: response.data.flag
                };
            }
        })
        .catch(error => {
            return {
                status: error.status,
                message: error.response
            };
        })
}

function checkPass(body){
    return instance.post(`/checkpass`, body)
        .then(response => {
            if (response.status === 200){
                return {
                    status: response.data.success,
                };
            }
        })
        .catch(error => {
            return {
                status: error.status,
                message: error.response
            };
        })
}

export const catalogApi = {
    getPayload: getData,
    addDish: postDish,
    checkPassword: checkPass
}
