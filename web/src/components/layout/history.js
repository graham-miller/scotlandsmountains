import createHistory from 'history/lib/createHashHistory';
import useQueries from 'history/lib/useQueries'
import { useRouterHistory } from 'react-router';

const options = { queryKey: false };

const routerHistory = useRouterHistory(createHistory)(options);
const history = useQueries(createHistory)(options);

export { routerHistory, history };
