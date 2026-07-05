import { Route, Routes } from 'react-router-dom'
import { AuthProvider, RequireAdmin, RequireAuth } from './lib/auth'
import { AppLayout } from './layouts/AppLayout'
import LoginPage from './pages/LoginPage'
import HomePage from './pages/HomePage'
import UsersPage from './pages/UsersPage'
import CollectResultsPage from './pages/CollectResultsPage'
import CollectStatsPage from './pages/CollectStatsPage'

export default function App() {
  return (
    <AuthProvider>
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route
          element={
            <RequireAuth>
              <AppLayout />
            </RequireAuth>
          }
        >
          <Route path="/" element={<HomePage />} />
          <Route
            path="/configuracoes/usuarios"
            element={
              <RequireAdmin>
                <UsersPage />
              </RequireAdmin>
            }
          />
          <Route
            path="/sistemas/coleta-resultado"
            element={
              <RequireAdmin>
                <CollectResultsPage />
              </RequireAdmin>
            }
          />
          <Route
            path="/sistemas/coleta-estatisticas"
            element={
              <RequireAdmin>
                <CollectStatsPage />
              </RequireAdmin>
            }
          />
        </Route>
      </Routes>
    </AuthProvider>
  )
}
