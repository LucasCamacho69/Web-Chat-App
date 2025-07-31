import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { EnterUsername } from './pages/enter-username';


const queryClient = new QueryClient();

export function App() {

  return (
    <QueryClientProvider client={queryClient}>
      <BrowserRouter>
        <Routes>
          <Route index element={<EnterUsername />} />
        </Routes>
      </BrowserRouter>
    </QueryClientProvider>
  )
}

