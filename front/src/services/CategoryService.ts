import axios from "axios"

const url = "localhost:8080/categories"

async function getCategories() : Promise<Category[]>{
    const res = await axios.get(url,{
        headers:{Authorization:""}
    })

    const categories:Category[] = [
        {
            id: 15,
            name: "CATEGORY 1"
        },
        {
            id: 13,
            name: "CATEGORY 2"
        },
        {
            id: 11,
            name: "CATEGORY 3"
        },
        {
            id: 6,
            name: "CATEGORY stgsdgsdg"
        }
    ]
    console.log(res.data)
    return res.data
}

const CategoryService = {
    getCategories,

}

export default CategoryService