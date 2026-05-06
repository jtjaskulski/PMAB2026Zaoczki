import React, { useState } from 'react';
import { StyleSheet } from 'react-native';
import { SafeAreaProvider, SafeAreaView } from 'react-native-safe-area-context';

import LoginScreen from './src/screens/LoginScreen';
import HomeScreen from './src/screens/HomeScreen';
import CrudScreen from './src/screens/CrudScreen';

export type ModuleName =
  | 'Rowery'
  | 'Klienci'
  | 'Wypożyczenia'
  | 'Serwis'
  | 'Płatności'
  | 'Typy rowerów'
  | 'Kategorie'
  | 'Metody Płatności';

function App(): React.JSX.Element {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [screen, setScreen] = useState<'home' | 'crud'>('home');
  const [currentModule, setCurrentModule] = useState<ModuleName>('Rowery');

  const handleLogout = () => {
    setIsLoggedIn(false);
    setScreen('home');
  };

  const openModule = (moduleName: ModuleName) => {
    setCurrentModule(moduleName);
    setScreen('crud');
  };

  return (
    <SafeAreaProvider>
      <SafeAreaView style={styles.container} edges={['top', 'bottom']}>
        {!isLoggedIn ? (
          <LoginScreen onLogin={() => setIsLoggedIn(true)} />
        ) : screen === 'home' ? (
          <HomeScreen
            onOpenModule={openModule}
            onLogout={handleLogout}
          />
        ) : (
          <CrudScreen
            moduleName={currentModule}
            onBack={() => setScreen('home')}
          />
        )}
      </SafeAreaView>
    </SafeAreaProvider>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#0F172A',
  },
});

export default App;