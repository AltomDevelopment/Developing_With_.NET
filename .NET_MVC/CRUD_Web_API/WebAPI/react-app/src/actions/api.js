import axios from "axios";//Promise based HTTP client for the browser and node. js (A Promise is an object that represents an asynchronous operation)

const baseURL = "http://localhost:portNumber/DCandidate"//If the app isn't displaying the data it is likely a port or url issue

export default {

    dCandidate(url = baseURL){
        return{
            fetchAll : () => axios.get(url),
            fetchById : id => axios.get(url+id),
            create : newRecord => axios.post(url,newRecord),
            update : (id,updateRecord) => axios.put(url+id,updateRecord),
            delete : id => axios.delete(url + id) 
        }
    }
}