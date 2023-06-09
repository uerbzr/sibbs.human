import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { FetchPeopleData } from "./components/FetchPeopleData";
import { AuthorsData } from "./components/AuthorsData";
import { Home } from "./components/Home";
import { NameForm } from "./components/NameForm"

const AppRoutes = [
  {
    index: true,
    element: <Home />
    },
    {
    path: '/counter',
    element: <Counter />
    },
    {
    path: '/fetch-data',
    element: <FetchData />
    },    
    {
        path: '/fetch-people-data',
        element: <FetchPeopleData />
    },
    {
        path: '/authors',
        element: <AuthorsData />
    },
    {
        path: '/addauthor',
        element: <NameForm />
    }
];

export default AppRoutes;
