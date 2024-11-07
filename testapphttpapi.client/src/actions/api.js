import axsios from "axios";
import { Employee } from "../reducers/Employee";
import { fetchAll } from "./Employee";
import axios from "axios";

const baseUrl = "https://localhost:7200/api/"

//долго боролся с выполнением запросов через fetch (постоянные ошибки даже при запросе на вывод всех сотрудников)
//получилось реализовать через axios

export default {
    Employee(url = baseUrl + "employees/") {
        return {
            fetchAll: () => axios.get(url + "all/"),
            fetchById: id => axios.get(url + "employee/" + id),
            create: newRecord => axios.post(url + "hire/", newRecord),
            update: (Id, updateRecord) => axios.put(url + "fire/" + Id, updateRecord),
            delete: Id => axios.delete(url + "delete/" + Id)
        }
    }
}
