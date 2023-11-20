import { Home } from "./components/Home";
import { AllData } from "./components/AllData";
import { Metals } from "./components/Metals";
import { ParameterYears } from "./components/ParameterYears";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/all-data',
    element: <AllData />
  },
  {
    path: '/metals',
    element: <Metals />
  },
  {
    path: '/years',
      element: <ParameterYears />
  }
];

export default AppRoutes;
